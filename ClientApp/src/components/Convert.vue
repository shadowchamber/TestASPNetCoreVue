<template>
    <div>
        <p>
            Markdown text:
        </p>
        <textarea placeholder="add multiple lines" v-model="convertingText" rows="10" cols="50"></textarea>
        <br />
        <p>
            Converted text:
        </p>
        <div v-html="convertedText"></div>
        <br />
        <p>
            Source:
        </p>
        <pre>{{ convertedText }}</pre>
        <br />
        <p>
            <v-btn class="ma-2" color="info" @click.prevent="convert">Convert</v-btn>
        </p>

        <v-alert :value="showError"
                 type="error"
                 v-text="errorMessage">
            This is an error alert.
        </v-alert>

        <v-alert :value="showError"
                 type="warning">
            Are you sure you're using ASP.NET Core endpoint? (default at <a href="http://localhost:5000/fetch-data">http://localhost:5000</a>)<br>
            API call would fail with status code 404 when calling from Vue app (default at <a href="http://localhost:8080/fetch-data">http://localhost:8080</a>) without devServer proxy settings in vue.config.js file.
        </v-alert>
    </div>
</template>

<script lang="ts">
import 'reflect-metadata';
import { Action, Getter } from 'vuex-class';
import { Component, Vue, Prop } from 'vue-property-decorator';
const namespace: string = 'convert';

@Component
export default class Convert extends Vue {
    private loading: boolean = true;
    private showError: boolean = false;
    private errorMessage: string = 'Error while loading converted text.';

    private convertingTextData: string = "";

    public get convertingText(): string {
        return this.convertingTextData;
    }

    public set convertingText(value: string) {
        this.convertingTextData = value;
    }

    @Getter('convertedText', { namespace })
    private convertedText!: string;  
    @Action('convert', { namespace })
    private convertText: any;

    private convert() {
        try {
          this.convertText(this.convertingText);
        } catch (e) {
          this.showError = true;
          this.errorMessage = `Error while loading converted text: ${e.message}.`;
        }
        this.loading = false;
    }
}
</script>

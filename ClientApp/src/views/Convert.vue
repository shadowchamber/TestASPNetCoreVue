<template>
    <v-container fluid>
        <v-slide-y-transition mode="out-in">
            <v-row>
                <v-col>
                    <h1>Converter to HTML</h1>
                    <p>This is a conversion test from markdown text to HTML</p>
                    <Convert />
                </v-col>
            </v-row>
        </v-slide-y-transition>
    </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Convert from '@/components/Convert.vue';

    @Component({
        components: { Convert },
    })
    export default class ConvertView extends Vue { }
</script>



import { MutationTree } from 'vuex';
import { ConvertState } from './types';
import axios, { AxiosResponse } from 'axios';

export const mutations: MutationTree<ConvertState> = {
    async convertText(state, inputText) {
        var text = inputText;

        const response = await axios({
            method: "POST",
            url: "api/Convert",
            headers: {
                'accept': 'text/plain',
                'accept-language': 'en_US',
                'content-type': 'text/plain'
            },
            data: text
        });

        state.convertedText = response.data;
  },
};

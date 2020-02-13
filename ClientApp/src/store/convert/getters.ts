import { GetterTree } from 'vuex';
import { ConvertState } from './types';
import { RootState } from '../types';

export const getters: GetterTree<ConvertState, RootState> = {
    convertedText(state): string {
        return state.convertedText;
    },
    convertingText(state): string {
        return state.convertingText;
    },
};

import { ActionTree } from 'vuex';
import axios from 'axios';
import { ConvertState } from './types';
import { RootState } from '../types';

export const actions: ActionTree<ConvertState, RootState> = {
  convert({ commit }, inputText): any {
      commit('convertText', inputText);
  },
};

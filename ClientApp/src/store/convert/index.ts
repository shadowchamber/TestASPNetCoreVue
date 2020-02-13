import { Module } from 'vuex';
import { getters } from './getters';
import { actions } from './actions';
import { mutations } from './mutations';
import { ConvertState } from './types';
import { RootState } from '../types';

export const state: ConvertState = {
    convertedText: '',
    convertingText: '',
};

const namespaced: boolean = true;

export const convert: Module<ConvertState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations,
};

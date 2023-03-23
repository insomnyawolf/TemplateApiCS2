/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Project } from './Project';

export type Company = {
    id?: number;
    companyId?: number;
    readonly projects?: Array<Project> | null;
};

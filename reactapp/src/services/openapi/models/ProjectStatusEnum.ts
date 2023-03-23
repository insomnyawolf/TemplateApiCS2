/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Project } from './Project';

export type ProjectStatusEnum = {
    id?: number;
    value?: string | null;
    readonly projects?: Array<Project> | null;
};

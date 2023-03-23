/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Project } from './Project';

export type ProjectGroup = {
    id?: number;
    groupId?: string | null;
    readonly projects?: Array<Project> | null;
};

/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Project } from './Project';

export type WindTurbine = {
    id?: number;
    projectId?: number;
    code?: string | null;
    project?: Project;
};

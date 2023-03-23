/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ProjectStatusEnum } from '../models/ProjectStatusEnum';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ProjectStatusEnumService {

    /**
     * @param id 
     * @returns ProjectStatusEnum Success
     * @throws ApiError
     */
    public static getProjectStatusEnum(
id?: number,
): CancelablePromise<Array<ProjectStatusEnum>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/ProjectStatusEnum',
            query: {
                'id': id,
            },
        });
    }

}

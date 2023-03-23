/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ProjectDealTypeEnum } from '../models/ProjectDealTypeEnum';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ProjectDealTypeEnumService {

    /**
     * @param id 
     * @returns ProjectDealTypeEnum Success
     * @throws ApiError
     */
    public static getProjectDealTypeEnum(
id?: number,
): CancelablePromise<Array<ProjectDealTypeEnum>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/ProjectDealTypeEnum',
            query: {
                'id': id,
            },
        });
    }

}

/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Project } from '../models/Project';
import type { ProjectGroup } from '../models/ProjectGroup';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ProjectGroupService {

    /**
     * @param id 
     * @param groupId 
     * @param projects 
     * @returns ProjectGroup Success
     * @throws ApiError
     */
    public static getProjectGroup(
id?: number,
groupId?: string,
projects?: Array<Project>,
): CancelablePromise<Array<ProjectGroup>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/ProjectGroup',
            query: {
                'Id': id,
                'GroupId': groupId,
                'Projects': projects,
            },
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static postProjectGroup(
requestBody?: ProjectGroup,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/ProjectGroup',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static putProjectGroup(
requestBody?: ProjectGroup,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/ProjectGroup',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param itemId 
     * @returns ProjectGroup Success
     * @throws ApiError
     */
    public static deleteProjectGroup(
itemId?: number,
): CancelablePromise<ProjectGroup> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/ProjectGroup',
            query: {
                'itemId': itemId,
            },
        });
    }

}

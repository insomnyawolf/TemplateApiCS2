/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Company } from '../models/Company';
import type { Project } from '../models/Project';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class CompanyService {

    /**
     * @param id 
     * @param companyId 
     * @param projects 
     * @returns Company Success
     * @throws ApiError
     */
    public static getCompany(
id?: number,
companyId?: number,
projects?: Array<Project>,
): CancelablePromise<Array<Company>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Company',
            query: {
                'Id': id,
                'CompanyId': companyId,
                'Projects': projects,
            },
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static postCompany(
requestBody?: Company,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Company',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static putCompany(
requestBody?: Company,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/Company',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param itemId 
     * @returns Company Success
     * @throws ApiError
     */
    public static deleteCompany(
itemId?: number,
): CancelablePromise<Company> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/Company',
            query: {
                'itemId': itemId,
            },
        });
    }

}

/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Project } from '../models/Project';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ProjectService {

    /**
     * @param idMin 
     * @param idMax 
     * @param companyIdMin 
     * @param companyIdMax 
     * @param groupIdMin 
     * @param groupIdMax 
     * @param statusIdMin 
     * @param statusIdMax 
     * @param dealTypeIdMin 
     * @param dealTypeIdMax 
     * @param monthsAcquiredMin 
     * @param monthsAcquiredMax 
     * @param kwMin 
     * @param kwMax 
     * @returns Project Success
     * @throws ApiError
     */
    public static getProject(
idMin?: number,
idMax?: number,
companyIdMin?: number,
companyIdMax?: number,
groupIdMin?: number,
groupIdMax?: number,
statusIdMin?: number,
statusIdMax?: number,
dealTypeIdMin?: number,
dealTypeIdMax?: number,
monthsAcquiredMin?: number,
monthsAcquiredMax?: number,
kwMin?: number,
kwMax?: number,
): CancelablePromise<Array<Project>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Project',
            query: {
                'IdMin': idMin,
                'IdMax': idMax,
                'CompanyIdMin': companyIdMin,
                'CompanyIdMax': companyIdMax,
                'GroupIdMin': groupIdMin,
                'GroupIdMax': groupIdMax,
                'StatusIdMin': statusIdMin,
                'StatusIdMax': statusIdMax,
                'DealTypeIdMin': dealTypeIdMin,
                'DealTypeIdMax': dealTypeIdMax,
                'MonthsAcquiredMin': monthsAcquiredMin,
                'MonthsAcquiredMax': monthsAcquiredMax,
                'KwMin': kwMin,
                'KwMax': kwMax,
            },
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static postProject(
requestBody?: Project,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/Project',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static putProject(
requestBody?: Project,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/Project',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param itemId 
     * @returns Project Success
     * @throws ApiError
     */
    public static deleteProject(
itemId?: number,
): CancelablePromise<Project> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/Project',
            query: {
                'itemId': itemId,
            },
        });
    }

}

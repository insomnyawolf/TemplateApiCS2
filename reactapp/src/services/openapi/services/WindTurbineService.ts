/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Project } from '../models/Project';
import type { WindTurbine } from '../models/WindTurbine';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class WindTurbineService {

    /**
     * @param id 
     * @param projectId 
     * @param code 
     * @param projectId 
     * @param projectCompanyId 
     * @param projectGroupId 
     * @param projectStatusId 
     * @param projectDealTypeId 
     * @param projectNumber 
     * @param projectName 
     * @param projectAcquisitionDate 
     * @param projectMonthsAcquired 
     * @param projectNumber3Lcode 
     * @param projectKw 
     * @param projectCompanyId 
     * @param projectCompanyCompanyId 
     * @param projectCompanyProjects 
     * @param projectDealTypeId 
     * @param projectDealTypeValue 
     * @param projectDealTypeProjects 
     * @param projectGroupId 
     * @param projectGroupGroupId 
     * @param projectGroupProjects 
     * @param projectStatusId 
     * @param projectStatusValue 
     * @param projectStatusProjects 
     * @param projectWindTurbines 
     * @returns WindTurbine Success
     * @throws ApiError
     */
    public static getWindTurbine(
id?: number,
projectId?: number,
code?: string
): CancelablePromise<Array<WindTurbine>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/WindTurbine',
            query: {
                'Id': id,
                'ProjectId': projectId,
                'Code': code,
            },
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static postWindTurbine(
requestBody?: WindTurbine,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/WindTurbine',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody 
     * @returns number Success
     * @throws ApiError
     */
    public static putWindTurbine(
requestBody?: WindTurbine,
): CancelablePromise<number> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/WindTurbine',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param itemId 
     * @returns WindTurbine Success
     * @throws ApiError
     */
    public static deleteWindTurbine(
itemId?: number,
): CancelablePromise<WindTurbine> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/WindTurbine',
            query: {
                'itemId': itemId,
            },
        });
    }

}

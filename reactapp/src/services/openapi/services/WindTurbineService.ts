/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { WindTurbine } from '../models/WindTurbine';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class WindTurbineService {

    /**
     * @param idMin 
     * @param idMax 
     * @param projectIdMin 
     * @param projectIdMax 
     * @returns WindTurbine Success
     * @throws ApiError
     */
    public static getWindTurbine(
idMin?: number,
idMax?: number,
projectIdMin?: number,
projectIdMax?: number,
): CancelablePromise<Array<WindTurbine>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/WindTurbine',
            query: {
                'IdMin': idMin,
                'IdMax': idMax,
                'ProjectIdMin': projectIdMin,
                'ProjectIdMax': projectIdMax,
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

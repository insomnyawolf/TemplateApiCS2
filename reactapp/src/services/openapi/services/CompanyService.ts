/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Company } from '../models/Company';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class CompanyService {

    /**
     * @param idMin 
     * @param idMax 
     * @param companyIdMin 
     * @param companyIdMax 
     * @returns Company Success
     * @throws ApiError
     */
    public static getCompany(
idMin?: number,
idMax?: number,
companyIdMin?: number,
companyIdMax?: number,
): CancelablePromise<Array<Company>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Company',
            query: {
                'IdMin': idMin,
                'IdMax': idMax,
                'CompanyIdMin': companyIdMin,
                'CompanyIdMax': companyIdMax,
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

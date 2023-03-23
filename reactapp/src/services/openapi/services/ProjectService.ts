/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Project } from '../models/Project';
import type { WindTurbine } from '../models/WindTurbine';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ProjectService {

    /**
     * @param id 
     * @param companyId 
     * @param groupId 
     * @param statusId 
     * @param dealTypeId 
     * @param number 
     * @param name 
     * @param acquisitionDate 
     * @param monthsAcquired 
     * @param number3Lcode 
     * @param kw 
     * @param companyId 
     * @param companyCompanyId 
     * @param companyProjects 
     * @param dealTypeId 
     * @param dealTypeValue 
     * @param dealTypeProjects 
     * @param groupId 
     * @param groupGroupId 
     * @param groupProjects 
     * @param statusId 
     * @param statusValue 
     * @param statusProjects 
     * @param windTurbines 
     * @returns Project Success
     * @throws ApiError
     */
    public static getProject(
id?: number,
companyId?: number,
groupId?: number,
statusId?: number,
dealTypeId?: number,
number?: string,
name?: string,
acquisitionDate?: string,
monthsAcquired?: number,
number3Lcode?: string,
kw?: number,
companyId?: number,
companyCompanyId?: number,
companyProjects?: Array<Project>,
dealTypeId?: number,
dealTypeValue?: string,
dealTypeProjects?: Array<Project>,
groupId?: number,
groupGroupId?: string,
groupProjects?: Array<Project>,
statusId?: number,
statusValue?: string,
statusProjects?: Array<Project>,
windTurbines?: Array<WindTurbine>,
): CancelablePromise<Array<Project>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/Project',
            query: {
                'Id': id,
                'CompanyId': companyId,
                'GroupId': groupId,
                'StatusId': statusId,
                'DealTypeId': dealTypeId,
                'Number': number,
                'Name': name,
                'AcquisitionDate': acquisitionDate,
                'MonthsAcquired': monthsAcquired,
                'Number3Lcode': number3Lcode,
                'Kw': kw,
                'Company.Id': companyId,
                'Company.CompanyId': companyCompanyId,
                'Company.Projects': companyProjects,
                'DealType.Id': dealTypeId,
                'DealType.Value': dealTypeValue,
                'DealType.Projects': dealTypeProjects,
                'Group.Id': groupId,
                'Group.GroupId': groupGroupId,
                'Group.Projects': groupProjects,
                'Status.Id': statusId,
                'Status.Value': statusValue,
                'Status.Projects': statusProjects,
                'WindTurbines': windTurbines,
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

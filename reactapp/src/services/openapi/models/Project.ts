/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Company } from './Company';
import type { ProjectDealTypeEnum } from './ProjectDealTypeEnum';
import type { ProjectGroup } from './ProjectGroup';
import type { ProjectStatusEnum } from './ProjectStatusEnum';
import type { WindTurbine } from './WindTurbine';

export type Project = {
    id?: number;
    companyId?: number;
    groupId?: number;
    statusId?: number;
    dealTypeId?: number;
    number?: string | null;
    name?: string | null;
    acquisitionDate?: string | null;
    monthsAcquired?: number | null;
    number3Lcode?: string | null;
    kw?: number;
    company?: Company;
    dealType?: ProjectDealTypeEnum;
    group?: ProjectGroup;
    status?: ProjectStatusEnum;
    readonly windTurbines?: Array<WindTurbine> | null;
};

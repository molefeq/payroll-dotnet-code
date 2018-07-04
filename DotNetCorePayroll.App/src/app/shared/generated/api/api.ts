export * from './account.service';
import { AccountService } from './account.service';
export * from './organisation.service';
import { OrganisationService } from './organisation.service';
export * from './referenceData.service';
import { ReferenceDataService } from './referenceData.service';
export * from './role.service';
import { RoleService } from './role.service';
export const APIS = [AccountService, OrganisationService, ReferenceDataService, RoleService];

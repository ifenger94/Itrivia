import { ROLES_ENUM } from "@data/contants";

export interface IApiUserAuthenticated {
    LifeTime: Date
    ProfileId: number
    RolCode: ROLES_ENUM
    UserId: number
    Jwt: string
}
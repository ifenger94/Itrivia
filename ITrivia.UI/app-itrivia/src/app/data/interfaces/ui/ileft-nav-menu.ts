import { ROLES_ENUM } from "@data/contants";

export interface ILeftNavMenu {
    name: string;
    icon: any;
    route?:string;
    permission?:ROLES_ENUM[]
    method?:() => any;
    links?: {
        icon: any;
        name: string
        route?:string
        permission?:ROLES_ENUM[]
    }[]
}
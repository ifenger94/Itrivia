import { ILeftNavMenu } from "@data/interfaces/ui/ileft-nav-menu";
import { CONFIGURATION_ACCESS } from "../Permissions/configuration-access";

export const LEFT_NAV_MENU_MANAGMENT: ILeftNavMenu[] = [
    {
        name: 'explore',
        icon: 'fas fa-desktop',
        route:'/Managment/sections',
        permission:CONFIGURATION_ACCESS.MANAGMENT_EXPLORE
    },
    {
        name: 'progress',
        icon: 'fas fa-chart-pie',
        permission:CONFIGURATION_ACCESS.MANAGMENT_PROGRESS,
        links: [{
            name: 'exp-weekly',
            icon: 'fas fa-chart-bar',
            route:'/Managment/weeklyexp',
            permission:CONFIGURATION_ACCESS.MANAGMENT_PROGRESS_EXPWEEKLY
        },
        {
            name: 'rank-gen',
            icon: 'fas fa-signal',
            route:'/Managment/rankgen',
            permission:CONFIGURATION_ACCESS.MANAGMENT_PROGRESS_RANKGEN
        }]
    },
    {
        name: 'profile',
        icon: 'fas fa-walking',
        route:'/Managment/profile',
        permission:CONFIGURATION_ACCESS.MANAGMENT_PROFILE
    },
    {
        name: 'configuration',
        icon: 'fas fa-cogs',
        permission:CONFIGURATION_ACCESS.MANAGMENT_CONFIGURATION,
        links: [{
            name: 'sections',
            icon: 'fas fa-book',
            route:'/Administrator/abm-sections',
            permission:CONFIGURATION_ACCESS.MANAGMENT_ABM_SECTIONS
        },
        {
            name: 'challenges',
            icon: 'fas fa-atlas',
            route:'/Administrator/abm-challenges',
            permission:CONFIGURATION_ACCESS.MANAGMENT_ABM_CHALLENGES
        },
        {
            name: 'users',
            icon: 'fas fa-address-book',
            route:'/Administrator/abm-users',
            permission:CONFIGURATION_ACCESS.MANAGMENT_ABM_USERS
        }]
    }
]
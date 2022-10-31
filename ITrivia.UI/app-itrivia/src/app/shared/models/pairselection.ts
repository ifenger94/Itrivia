export class PairSelection {
    Id:number;
    PairOptions:Array<{Option:string,Pair:string}>;
}

export class PairSelectionGameDto{
    Id: number
    IsDeleted: boolean
    CreateDate: Date
    ModifyDate: Date
    User: string
    FirstOption:string
    FirstAnswer:string
    SecondOption:string
    SecondAnswer:string
    ThirdOption:string
    ThirdAnswer:string
    FourthOption:string
    FourthAnswer:string
}

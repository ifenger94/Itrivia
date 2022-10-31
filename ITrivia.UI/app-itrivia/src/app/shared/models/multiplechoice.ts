export class MultipleChoice {
    Id: number
    IsDeleted: boolean
    CreateDate: Date
    ModifyDate: Date
    User: string
    Enunciate: string
    ChallengeId: string
    CorrectOption: string
    FirstOption: string
    SecondOption: string
}

export class MultipleChoiceGameDto {
    Id: number
    IsDeleted: boolean
    CreateDate: Date
    ModifyDate: Date
    User: string
    Enunciate: string
    CorrectOption: string
    FirstOption: string
    SecondOption: string
}
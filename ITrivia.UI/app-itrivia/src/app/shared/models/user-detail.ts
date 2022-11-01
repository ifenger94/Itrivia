import { Image } from "./image";
import { Profile } from "./profile";
import { Rol } from "./rol";


export class UserDetail{
    Id : number
    IsDeleted: boolean
    CreateDate: Date
    ModifyDate: Date
    Email :string
    Name :string
    LastName :string
    BussinesId :number
    RolId :number
    ProfileId :number
    Profile:Profile
    Image:Image
    Rol:Rol
}
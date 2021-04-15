import { Discount } from './Discount';
import { UserType } from "./UserType";

export class User{
    public Id:number;    
    public UserTypeId:number;
    
    public FirstName: string;
    public LastName: string;

    public UserType: UserType;

    public Discount: Discount;

    constructor() {}
}
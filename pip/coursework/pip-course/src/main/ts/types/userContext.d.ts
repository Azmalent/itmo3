import UserType from "./userType";

export interface IUserContext {
    id? : number;
    username?: string;
    userType?: UserType;
    login:  () => void;
    logout: () => void;
}

export default IUserContext;
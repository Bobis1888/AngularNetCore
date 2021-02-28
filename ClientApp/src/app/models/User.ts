import {Settings} from "./Settings";

export class User {
  constructor(
    public id?: number,
    public email?: string,
    public trusted = false,
    public password?: string,
    public settings?: Settings) {}
}

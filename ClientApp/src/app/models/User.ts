export class User {
  constructor(
    public id?: number,
    public email?: string,
    public trusted?: boolean,
    public password?: string) { }
}

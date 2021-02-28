export class Flow {
  constructor(
  private id?: number,
  public name?: string,
  public subFlows?: Array<string>
  ){}
}

export class Settings {
  constructor(
    private id?: number,
    public email?: string,
    public flows?: Flow[]
  ) { }
}

import {User} from "./User";
import {Item} from "./Item";
import {Settings} from "./Settings";

export class ASPResponse {
  constructor(
    public sessionId?: string,
    public items?: Item[],
    public settings?: Settings,
    public user?: User,
  ) { }
}

import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component } from '@angular/core';
import {User} from "../models/User";
import {AccountService} from "../services/account.service";


@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./components.css'],
    providers: [AccountService]
  })
export class AppComponent {

  reference: any;
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher,private accountService: AccountService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  update() {
    this.reference.load();
  }

  onActivate (componentReference) {
    this.reference = componentReference;
  }

  getCurrentAccount(): User {
    return AccountService.currentUser;
  }

  logout() {
    this.accountService.logout();
  }

}

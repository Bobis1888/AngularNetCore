import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource } from '@angular/material';
import { catchError,tap } from 'rxjs/operators';
import {Flow} from "../../models/Settings";

class Node {

  constructor(
    public flow: string,
    public subflows?:Array<Node>
  ) {}

}

@Component({
  templateUrl: './account-info.component.html',
  providers: [AccountService],
  styleUrls: ['../components.css']
})
export class AccountInfoComponent implements OnInit{

  treeControl = new NestedTreeControl<Node>(node => node.subflows);
  dataSource = new MatTreeNestedDataSource<Node>();
  progress = true;
  user: User;
  flows: string;
  subFlows: string;

  constructor(private accountService: AccountService,private router: Router) {}

  hasChild = (_: number, node: Node) => !!node.subflows && node.subflows.length > 0;

  ngOnInit() {
    this.accountService.info().then(() => {
      this.user = AccountService.currentUser
      if (!this.user.trusted) {
        this.router.navigate(['login']);
      }
      this.load();
    });
  }

  load() {
    console.log(this.accountService.getCurrentUser().settings);
    this.dataSource.data = new Array<Node>(this.accountService.getCurrentUser().settings.flows.length);
    this.accountService.getCurrentUser().settings.flows.forEach(((value:Flow,index) => {
      let arraySubFLows = new Array<Node>(value.subFlows.length);
      value.subFlows.forEach((fl,index) => arraySubFLows[index] = new Node(fl));
      this.dataSource.data[index] = new Node(value.name,arraySubFLows);
    }));
    this.progress = false;
  }

}

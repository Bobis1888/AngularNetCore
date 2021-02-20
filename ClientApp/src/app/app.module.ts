import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ItemListComponent } from './components/item-list.component';
import { NotFoundComponent } from './components/not-found.component';
import { DataService } from './data.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatIconModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule, MatTabsModule, MatToolbarModule } from '@angular/material';
import { ItemBodyComponent } from './components/item-body.component';


const appsRoutes: Routes = [
  { path: '', component: ItemListComponent },
  { path: 'body/:postId', component: ItemBodyComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ItemListComponent,
    ItemBodyComponent,
    NotFoundComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appsRoutes),
    BrowserAnimationsModule,
    MatTabsModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatToolbarModule

  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }

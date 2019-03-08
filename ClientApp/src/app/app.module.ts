import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BranchService } from './apiServices/branchApi.service';
import { NgbdTabset } from './components/tabset/tabset.component';
import { NgbdTable } from './components/table/table.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NgbdTabset,
    NgbdTable
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [BranchService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CoreModule } from '@core/core.module';
import { InitModule } from '@modules/init/init.module';
import { SharedModule } from '@shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { FooterComponent } from '@layout/init/footer/footer.component';
import { NavigationComponent } from '@layout/init/navigation/navigation.component';
import { SkeletonComponent } from '@layout/init/skeleton/skeleton.component';
import { SkeletonManagmentComponent } from './layout/managment/skeleton-managment/skeleton-managment.component';
import { ManagmentModule } from '@modules/managment/managment.module';
import { SidebarManagmentComponent } from '@layout/managment/sidebar-managment/sidebar-managment.component';
import { LeftNavMenuComponent } from './layout/managment/left-nav-menu/left-nav-menu.component';





@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavigationComponent,
    SkeletonComponent,
    SkeletonManagmentComponent,
    SidebarManagmentComponent,
    LeftNavMenuComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    AppRoutingModule,
    SharedModule,
    InitModule,
    ManagmentModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()

  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

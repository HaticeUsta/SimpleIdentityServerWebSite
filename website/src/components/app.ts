import { Component, OnInit } from 'angular2/core';
import { RouteConfig } from 'angular2/router';
import { LoggedInOutlet } from './loggedInOutlet.ts';
import { LoginComponent } from './login/login.ts';
import { HomeComponent } from './home/home.ts';
import { Settings } from './settings.ts'

@Component({
    selector: 'app',
    template: require('./app.html'),
    styles: [ require('./app.scss') ],
    directives: [ LoggedInOutlet ],
    providers: [
        Settings
    ]
})

@RouteConfig([
    {
      path: '/',
      name: 'Index',
      component: HomeComponent,
      useAsDefault: true  
    },
    {
        path: '/login',
        name: 'Login',
        component: LoginComponent
    }
])

export class AppComponent implements OnInit {
    ngOnInit() {
        if (window.location.hash) {
            console.log('hash');
        }
    }
}
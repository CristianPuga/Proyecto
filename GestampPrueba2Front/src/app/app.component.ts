import { Component, OnInit } from '@angular/core';

import { Platform, MenuController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent implements OnInit {
  public selectedIndex = 0;
  public appPages = [
    {
      title: 'Login',
      url: '/login',
      icon: 'person'
    },
    {
      title: 'Personas',
      url: '/personas',
      icon: 'list'
    },
    {
      title: 'Usuarios',
      url: '/usuarios',
      icon: 'list'
    }
  ];

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    public menuCtrl: MenuController
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }

  ngOnInit() {
    const path = window.location.pathname.split('login/')[1];
    if (path !== undefined) {
      this.selectedIndex = this.appPages.findIndex(page => page.title.toLowerCase() === path.toLowerCase());
    }
  }

  /*ngDoCheck(){
    if (localStorage.getItem('token')){
      console.log("Usuario logeado");
      return true;
    }else{
      console.log("Usuario no logueado");     
      return false;
    }
  }*/

  enableAuthenticatedMenu() {
    this.menuCtrl.enable(true, 'first');
    this.menuCtrl.enable(false, 'first');
  }

  openMenu() {
    this.menuCtrl.open('first');
  }
 
  closeMenu() {
    console.log("he entrado");
    
    this.menuCtrl.close('first');
  }
}

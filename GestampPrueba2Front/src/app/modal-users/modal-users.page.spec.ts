import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ModalUsersPage } from './modal-users.page';

describe('ModalUsersPage', () => {
  let component: ModalUsersPage;
  let fixture: ComponentFixture<ModalUsersPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalUsersPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ModalUsersPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

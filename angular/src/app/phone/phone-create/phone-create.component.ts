import { Component, EventEmitter, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PhonelerDto, PhonelerServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-phone-create',
  templateUrl: './phone-create.component.html',
  styleUrls: ['./phone-create.component.css']
})
export class PhoneCreateComponent extends AppComponentBase implements OnInit {
  onSave = new EventEmitter<any>();
  saving =false;
  newPhone : PhonelerDto;
  constructor(
    injector: Injector,
    private _service: PhonelerServiceProxy,
    private bsModalRef:BsModalRef,
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.newPhone = new PhonelerDto();
  }

  PhoneOlustur(){
    this.newPhone.id=0;
    this.newPhone.satildiMi=false;
    this._service.create(this.newPhone).subscribe(
      ()=>{
        this.notify.info(this.l('Saved Succesful'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      ()=>{
        this.saving=false;
      }
    );
  }
}

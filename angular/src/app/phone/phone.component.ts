import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PhonelerDto, PhonelerServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PhoneCreateComponent } from './phone-create/phone-create.component';

@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.css']
})
export class PhoneComponent extends AppComponentBase implements OnInit {
  phoneler: PhonelerDto[];
  isCollapsed = true;
  isCollapsed2 = true;
  asd :PhonelerDto[];
  constructor(
    injector: Injector,
    private _service: PhonelerServiceProxy,
    private _modalService: BsModalService,
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.PhoneGetir();
  }

  PhoneGetir() {
    this._service.get().subscribe((res) => {
      this.phoneler = res;
    });
  }
   PhoneCreate() {
    let createOrEditAracDialog: BsModalRef;
    createOrEditAracDialog = this._modalService.show(
      PhoneCreateComponent,
      {
        class: 'modal-xl',
      }
    );
    createOrEditAracDialog.content.onSave.subscribe(() => {
      this.PhoneGetir();
    });
  }

  protected deletePhone(phone: PhonelerDto): void {
    abp.message.confirm(
      this.l(phone.marka + " " + phone.model + ' Silinecek onaylıyor musunuz?'),
      undefined,
      (result: boolean) => {
        if (result) {
          this._service.delete(phone.id).subscribe(() => {
            abp.notify.success(this.l('Başarıyla Silindi'));
            this.PhoneGetir();
          });
        }
      }
    );
  }
  showSatilmayanlar(){
    if(this.isCollapsed){
      this.isCollapsed2=true;
      this.isCollapsed = false;
    }
    this._service.satilmayanlariListele().subscribe((res) => {
      this.asd = res;
    });
  }
  showSatilanlar(){
    if(this.isCollapsed2){
      this.isCollapsed=true;
      this.isCollapsed2 = false;
    }
    this._service.satilanlariListele().subscribe((res) => {
      this.asd = res;
    });
  }
}

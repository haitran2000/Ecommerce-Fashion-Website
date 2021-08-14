import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../../../../environments/environment';
import { ToastServiceService } from '../../../shared/toast-service.service';
import { TaoPhieuNhapService } from '../tao-phieu-nhap.service';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
@Component({
  selector: 'app-tao-phieu-nhap',
  templateUrl: './tao-phieu-nhap.component.html',
  styleUrls: ['./tao-phieu-nhap.component.scss'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: { showError: true }
  }]
})
export class TaoPhieuNhapComponent implements OnInit {


  constructor(private service: TaoPhieuNhapService,
    private http: HttpClient,
    private serviceToast: ToastServiceService,
    private _formBuilder: FormBuilder
  ) { }
  chitiets: any = []
  nhacungcaps: any[] = [];
  sanphams: any[] = [];
  sanphambienthes: any[] = [];
  motnhacungcap:any
  ngOnInit(): void {

    this.service.getnhacungcaphttp().subscribe(
      data => {
        Object.assign(this.nhacungcaps, data)
      }
    )


    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: []
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: []
    });
    this.newFormGroupChiTiet = new FormGroup({
      GiaNhapSanPhamBienThe: new FormControl(null,
        [
          
        ]),
      TenSanPhamBienThe: new FormControl(null,
        [
          
        ]),
      SoLuongNhap: new FormControl(100,
        [
          Validators.required,
        ]),
    });
    this.newFormGroupPhieuNhap = new FormGroup({
      GhiChu: new FormControl(null,
        [
          Validators.required,
        ]),
    })
  }
  public firstFormGroup: FormGroup;
  public secondFormGroup: FormGroup;
  public newFormGroupChiTiet: FormGroup;
  public newFormGroupPhieuNhap: FormGroup;
  

  get TenSanPhamBienThe() { return this.newFormGroupChiTiet.get('TenSanPhamBienThe'); }
  get SoLuongNhap() { return this.newFormGroupChiTiet.get('SoLuongNhap'); }
  get GiaNhapSanPhamBienThe() { return this.newFormGroupChiTiet.get('GiaNhapSanPhamBienThe'); }
  get GhiChu() { return this.newFormGroupPhieuNhap.get('GhiChu'); }
  GiaNhapSanPhamBienThes(value){
    this.newFormGroupChiTiet.get('GiaNhapSanPhamBienThe').setValue(value)
  }
 
  getSanPhamNhaCungCap(event) {
    var obj = {
      id: event.target.value
    }
    console.log("object :", obj);

    this.service.gettensanphamhttp(obj).subscribe(res => {
      this.sanphams = res;
      console.log(this.sanphams);

    });

    this.service.getonenhacungcaphttp(obj).subscribe(res => {
      this.motnhacungcap = res;
      console.log("mot nha cung cap",this.motnhacungcap);

    });
  }
  getSanPhamBienTheSanPham(event) {
    var obj = {
      id: event.target.value
    }
    this.service.gettensanphambienthehttp(obj).subscribe(res => {
      this.sanphambienthes = res;
      console.log("san pham bien the",this.sanphambienthes);
      this.GiaNhapSanPhamBienThes(this.sanphambienthes[0].giaNhap)
    });
  }

  onSubmitChiTiet = (data) => {
    if (this.service.chitietphieunhap.id == 0) {
      const formData = new FormData();
      formData.append('GiaNhapSanPhamBienThe', data.GiaNhapSanPhamBienThe);
      formData.append('TenSanPhamBienThe', data.TenSanPhamBienThe);
      formData.append('SoLuongNhap', data.SoLuongNhap);
      console.log(data)
      this.chitiets.push(data)
      console.log("chi tiet", this.chitiets)
    }
    
  }
  public deleteDetail(item: any) {
    for (var index = 0; index < this.chitiets.length; index++) {
      let detail = this.chitiets[index];
      if ( detail.TenSanPhamBienThe == item.TenSanPhamBienThe
        && detail.SoLuongNhap == item.SoLuongNhap) {
        this.chitiets.splice(index, 1);
      }
    }
  }
  onSubmit = (data) => {
    if (this.service.phieunhap.id == 0) {
      const formData = new FormData();
      formData.append('Id_Loai', data.Id_Loai);
      formData.append('TenSize', data.TenSize);
      console.log(data)
      this.http.post(environment.URL_API + 'sizes', formData)
        .subscribe(res => {
          this.serviceToast.showToastThemThanhCong()
          this.service.getAllPhieuNhaps()
          this.service.phieunhap.id = 0;
        }, err => {
          this.serviceToast.showToastThemThatBai()
        });

    }
  }
}
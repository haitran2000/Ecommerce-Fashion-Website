import { Component, OnInit, OnDestroy, ViewChild, TemplateRef, Input, AfterViewInit,
    Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-age-verification',
  templateUrl: './age-verification.component.html',
  styleUrls: ['./age-verification.component.scss']
})
export class AgeVerificationComponent implements OnInit, AfterViewInit, OnDestroy {

  @ViewChild("ageVerification") AgeVerificationModal: TemplateRef<any>;

  public closeResult: string;
  public ageVerificationForm:  FormGroup;
  public currdate: any;
  public setDate: any;

  constructor(@Inject(PLATFORM_ID) private platformId: Object,
    private modalService: NgbModal,
  	private fb: FormBuilder) { 
  	this.ageVerificationForm = this.fb.group({
      day: ['', Validators.required],
      month: ['', Validators.required],
      year: ['', Validators.required],
    })
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
  	if(localStorage.getItem("ageVerification") !== 'true')
       this.openModal();
  }

  openModal() {
    if (isPlatformBrowser(this.platformId)) { // For SSR 
      this.modalService.open(this.AgeVerificationModal, { 
        size: 'md',
        backdrop: 'static',
        keyboard: false,
        centered: true,
        windowClass: 'bd-example-modal-md theme-modal agem'
      }).result.then((result) => {
        `Result ${result}`
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    }
  }

  ageForm() {
    var day = this.ageVerificationForm.value.day;
    var month = this.ageVerificationForm.value.month;
    var year = this.ageVerificationForm.value.year;
    var age = 18;
    var mydate = new Date();
    mydate.setFullYear(year, month-1, day);

    var currdate = new Date();
    this.currdate = currdate;
    var setDate = new Date();         
    this.setDate = setDate.setFullYear(mydate.getFullYear() + age, month-1, day);

    if ((this.currdate - this.setDate) > 0){
      localStorage.setItem('ageVerification','true')
      this.modalService.dismissAll();
    } else {
      window.location.href = "https://www.google.com/";
    }
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  ngOnDestroy() {
    
  }

}

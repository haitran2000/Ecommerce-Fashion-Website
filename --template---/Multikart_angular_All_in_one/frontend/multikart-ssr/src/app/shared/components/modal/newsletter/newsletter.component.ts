import { Component, OnInit, OnDestroy, ViewChild, TemplateRef, Input, AfterViewInit,
  Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-newsletter',
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss']
})
export class NewsletterComponent implements OnInit, AfterViewInit, OnDestroy {

  @ViewChild("newsletter", { static: false }) NewsLetterModal: TemplateRef<any>;

  public closeResult: string;
  public modalOpen: boolean = false;

  constructor(@Inject(PLATFORM_ID) private platformId: Object,
    private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    if(localStorage.getItem("newsletter") !== 'true')
       this.openModal();
    localStorage.setItem("newsletter", 'true');
  }

  openModal() {
    if (isPlatformBrowser(this.platformId)) { // For SSR 
      this.modalService.open(this.NewsLetterModal, { 
        size: 'lg',
        ariaLabelledBy: 'NewsLetter-Modal',
        centered: true,
        windowClass: 'theme-modal newsletterm NewsLetterModal'
      }).result.then((result) => {
        this.modalOpen = true;
        `Result ${result}`
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
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
    if(this.modalOpen){
      this.modalService.dismissAll();
    }
  }

}

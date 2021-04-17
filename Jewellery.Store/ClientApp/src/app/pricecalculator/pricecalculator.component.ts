import { CalculatorService } from './../services/calculator/calculator.service';
import { LoginService } from './../services/login/login.service';
import { PriceRequest } from 'src/app/models/PriceRequest';
import { LocalStorageService } from './../services/local-storage/local-storage.service';
import { Component, OnInit,ViewChild, ElementRef  } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { PriceResult } from '../models/PriceResult';

import jsPDF from 'jspdf';
import pdfMake from 'pdfmake/build/pdfmake';
import pdfFonts from 'pdfmake/build/vfs_fonts';
pdfMake.vfs = pdfFonts.pdfMake.vfs;
import htmlToPdfmake from 'html-to-pdfmake';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pricecalculator',
  templateUrl: './pricecalculator.component.html',
  styleUrls: ['./pricecalculator.component.css']
})

export class PricecalculatorComponent implements OnInit {
  @ViewChild('modalContent') modalContents: ElementRef;
  closeModal: string;
  priceResult:PriceResult;
  priceRequest: PriceRequest;
  discountApplicable:boolean;
  localStorageUserKey = 'user';
  userTypeDescription: string;

  constructor(private modalService:NgbModal,
    private _localStorageService:LocalStorageService,
    private _loginService:LoginService,
    private _calculatorService:CalculatorService,
    private router: Router,) {}

  ngOnInit(): void {
    this.priceRequest = new PriceRequest();
    this.priceResult = new PriceResult();
    
    var user = JSON.parse(this._localStorageService.getItem(this.localStorageUserKey));
    console.log('from localstorage' ,user);
    if(user){
      this._loginService.getUserInfo(user.id).subscribe((data: any) => {
        this.priceRequest.UserType = data.userTypeId;
        this.userTypeDescription = data.userType.type;
        this.discountApplicable = data.userTypeId === 2;
        if(this.discountApplicable){
          this.priceRequest.Discount = data.discount.discount;
        }
      });
    }
    else{
      this.router.navigate(['/login']);
    }
  }
  triggerModal(content) {
    this.modalService.open(content, { centered: true });
  }

  calculatePrice(){
    this._calculatorService.calculatePrice(this.priceRequest).subscribe((data: any) => {
      console.log(data);
      this.priceResult.TotalPrice = data.totalPrice;
    });
  } 

  public downloadAsPDF() {
    const doc = new jsPDF();
   
    const modalContent = this.modalContents.nativeElement;
   
    var html = htmlToPdfmake(modalContent.innerHTML);
     
    const documentDefinition = { content: html };
    pdfMake.createPdf(documentDefinition).open(); 
     
  } 
}

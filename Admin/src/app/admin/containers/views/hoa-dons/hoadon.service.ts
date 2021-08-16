import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";

import * as FileSaver from 'file-saver';
import * as XLSX from 'xlsx';

import { Workbook } from 'exceljs';
import * as fs from 'file-saver';
import { DatePipe } from '@angular/common';
import * as logoFile from './carlogo.js';
@Injectable({
  providedIn: 'root'
})
export class HoaDonService {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<HoaDon>();
  public dataSource2 = new MatTableDataSource<CTHDViewModel>();
  public dataOneBill: any[]
  public dataBills : any[]
  hoadon: HoaDon = new HoaDon()
  cthdViewModel: CTHDViewModel = new CTHDViewModel()
  readonly url = environment.URL_API + "hoadons"
  constructor(public http: HttpClient,private datePipe: DatePipe) { }
  get() {
    return this.http.get(this.url)
  }
  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`)
  }
  getHoaDon(id: number) {
    this.http.get(environment.URL_API + "hoadons/" + id).subscribe(
      res => {
        this.dataSource2.data = res as CTHDViewModel[];
        this.dataOneBill = res as CTHDViewModel[]
      }
    )
  }
  getAllHoaDons() {
    this.http.get(environment.URL_API + "hoadons").subscribe(
      res => {
        this.dataSource.data = res as HoaDon[];
        this.dataBills = res as HoaDon[]
      }
    )
  }

  public generateExcel(data:any) {
    
    //Excel Title, Header, Data
    const title = 'Car Sell Report';
    const header = ["Id", "Ngày tạo", "Ghi chú", "Tổng tiền", "User"]
   
    
     
    //Create workbook and worksheet
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet('Car Data');
    //Add Row and formatting
    let titleRow = worksheet.addRow([title]);
    titleRow.font = { name: 'Comic Sans MS', family: 4, size: 16, underline: 'double', bold: true }
    worksheet.addRow([]);
    let subTitleRow = worksheet.addRow(['Date : ' + this.datePipe.transform(new Date(), 'medium')])
    //Add Image
    let logo = workbook.addImage({
      base64: logoFile.logoBase64,
      extension: 'png',
    });
    worksheet.addImage(logo, 'E1:F3');
    worksheet.mergeCells('A1:D2');
    //Blank Row 
    worksheet.addRow([]);
    //Add Header Row
    let headerRow = worksheet.addRow(header);
    
    // Cell Style : Fill and Border
    headerRow.eachCell((cell, number) => {
      cell.fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'FFFFFF00' },
        bgColor: { argb: 'FF0000FF' }
      }
      cell.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } }
    })
    // worksheet.addRows(data);
    // Add Data and Conditional Formatting
  
    worksheet.addRows(data)
    worksheet.getColumn(3).width = 30;
    worksheet.getColumn(4).width = 30;
    worksheet.addRow([]);
    //Footer Row
    let footerRow = worksheet.addRow(['This is system generated excel sheet.']);
    footerRow.getCell(1).fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: { argb: 'FFCCFFE5' }
    };
    footerRow.getCell(1).border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } }
    //Merge Cells
    worksheet.mergeCells(`A${footerRow.number}:F${footerRow.number}`);
    //Generate Excel File with given name
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, 'CarData.xlsx');
    })
  }
}

export class HoaDon {
  id: number = 0
  id_User: string
  ngayTao:string
  ghiChi: string //Ghi chú
  tongTien: number
}
export class CTHDViewModel {
  idCTHD: number
  soLuong: number
  tenSanPham: string
  hinhAnh: string
  gia: number
  tenMau: string
  tenSize: string
  thanhTien: number
  id_HoaDon: number
}

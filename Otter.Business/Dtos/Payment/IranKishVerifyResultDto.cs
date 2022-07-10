﻿using System;

namespace Otter.Business.Dtos.Payment
{
    public class IranKishVerifyResultDto
    {
        public string responseCode { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public IranKishVerifyResultDataDto result { get; set; }
    }

    public class IranKishVerifyResultDataDto
    {
        public string responseCode { get; set; }
        public string systemTraceAuditNumber { get; set; }
        public string retrievalReferenceNumber { get; set; }
        public DateTime transactionDateTime { get; set; }
        public int transactionDate { get; set; }
        public int transactionTime { get; set; }
        public string processCode { get; set; }
        public object requestId { get; set; }
        public object additional { get; set; }
        public object billType { get; set; }
        public object billId { get; set; }
        public string paymentId { get; set; }
        public string amount { get; set; }
        public object revertUri { get; set; }
        public object acceptorId { get; set; }
        public object terminalId { get; set; }
        public object tokenIdentity { get; set; }
    }
}
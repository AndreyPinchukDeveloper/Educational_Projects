// See https://aka.ms/new-console-template for more information
using DelegatesAndEvents.Infrastructure;
using DelegatesAndEvents.Model;
using DelegatesAndEvents.Services;

var video = new VideoModel() { Title = "Video 1" };
var videoEncoder = new VideoEncoder();
var mailService = new MailService();
var messageService = new MessageService();

videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
videoEncoder.VideoEncoded += messageService.OnMessageEncoded;

videoEncoder.Encode(video);

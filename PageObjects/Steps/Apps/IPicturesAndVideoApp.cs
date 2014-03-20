﻿

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IPicturesAndVideoApp
    {
        IPicturesAndVideoApp VerifyElements();
        IPicturesAndVideoApp TakePicture();
        IPicturesAndVideoApp OpenTakenPicture();
        IPicturesAndVideoApp DeleteTakenPicture();
        IPicturesAndVideoApp RecordAVideo();
        IPicturesAndVideoApp OpenRecordedVideo();
        IPicturesAndVideoApp DeleteRecordedVideo();
        IPicturesAndVideoApp ExitApp();

    }
}
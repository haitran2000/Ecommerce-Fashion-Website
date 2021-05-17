import { 
    AdvancedLayout, 
    ButtonsConfig,
    ButtonsStrategy, 
    KS_DEFAULT_BTN_CLOSE, 
    KS_DEFAULT_BTN_DELETE, 
    KS_DEFAULT_BTN_DOWNLOAD, 
    KS_DEFAULT_BTN_EXTURL, 
    KS_DEFAULT_BTN_FULL_SCREEN, 
    PlainGalleryConfig, 
    PlainGalleryStrategy 
} from '@ks89/angular-modal-gallery';

// Button Configuration
export let ButtonsConfiguration: ButtonsConfig = {
    visible: true,
    strategy: ButtonsStrategy.CUSTOM,
    buttons: [
      KS_DEFAULT_BTN_FULL_SCREEN,
      KS_DEFAULT_BTN_DELETE,
      KS_DEFAULT_BTN_EXTURL,
      KS_DEFAULT_BTN_DOWNLOAD,
      KS_DEFAULT_BTN_CLOSE
    ]
};

// Gallery Configuration
export let PlainGalleryConfiguration: PlainGalleryConfig = {
    strategy: PlainGalleryStrategy.CUSTOM,
    layout: new AdvancedLayout(-1, true)
};

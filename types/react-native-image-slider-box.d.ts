// types/react-native-image-slider-box.d.ts

declare module "react-native-image-slider-box" {
  import { StyleProp, ViewStyle } from "react-native";

  interface SliderBoxProps {
    images: string[]; // Array of image URLs
    onCurrentImagePressed?: () => void; // Callback when the currently displayed image is pressed
    currentImageEmitter?: (index: number) => void; // Callback to get the index of the current image
    sliderBoxHeight?: number; // Height of the slider box
    dotColor?: string; // Color of the pagination dots
    inactiveDotColor?: string; // Color of inactive pagination dots
    paginationBoxVerticalPadding?: number; // Vertical padding of the pagination box
    autoplay?: boolean; // Enable autoplay
    circleLoop?: boolean; // Loop images in a circular manner
    parentWidth?: number; // Width of the parent container
    onEndReached?: () => void; // Callback when the end of the image list is reached
    onEndReachedThreshold?: number; // Threshold to trigger onEndReached
    paginationBoxStyle?: StyleProp<ViewStyle>; // Style for the pagination box container
    paginationBoxVerticalPosition?: "top" | "bottom"; // Vertical position of the pagination box
    paginationBoxHorizontalPosition?: "left" | "center" | "right"; // Horizontal position of the pagination box
    dotStyle?: StyleProp<ViewStyle>; // Style for the pagination dots
    ImageComponent?: React.ComponentType; // Custom component to be used for rendering images
    imageLoadingColor?: string; // Color of the loading spinner during image loading,
    ImageComponentStyle?: object;
    disableOnPress?: boolean; // Disable onPress events on images
    resizeMethod?: "auto" | "resize" | "scale"; // Resize method for images
    resizeMode?: "cover" | "contain" | "stretch" | "center"; // Resize mode for images
  }

  export const SliderBox: React.ComponentType<SliderBoxProps>;
}

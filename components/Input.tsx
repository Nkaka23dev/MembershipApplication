import { View, TextInput, StyleSheet } from "react-native";
import React from "react";

interface InputProps {
  Icon: any;
  iconName: string;
  placeholder: string;
  bgColor: string;
  mt?: number;
  pv?: number;
}

export default function Input({
  Icon,
  iconName,
  placeholder,
  bgColor,
  mt,
  pv,
}: InputProps) {
  const inputStyles = {
    backgroundColor: bgColor,
    marginTop: mt,
    paddingVertical: pv,
  };
  return (
    <View style={[styles.input, inputStyles]}>
      <Icon style={{ marginLeft: 16 }} name={iconName} size={24} color="gray" />
      <TextInput
        style={{
          width: 260,
          marginVertical: 10,
          marginLeft: 10,
          color: "black",
          borderRadius: 200,
        }}
        placeholder={placeholder}
      />
    </View>
  );
}
const styles = StyleSheet.create({
  img: {
    width: 150,
    height: 100,
  },
  input: {
    flexDirection: "row",
    alignItems: "center",
  },
});

import {
  View,
  Text,
  SafeAreaView,
  Image,
  StyleSheet,
  KeyboardAvoidingView,
  TextInput,
  Pressable,
} from "react-native";
import { Entypo } from "@expo/vector-icons";
import { Feather } from "@expo/vector-icons";

export default function Login() {
  return (
    <SafeAreaView style={{ flex: 1 }}>
      {/* I wnat it centered */}
      <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
        <Image
          style={styles.img}
          source={require("../assets/images/amazon.png")}
        />
        <KeyboardAvoidingView>
          <Text
            style={{
              fontSize: 16,
              fontWeight: "bold",
              textAlign: "center",
            }}
          >
            Login to your account
          </Text>
          <View style={{ marginTop: 70 }}>
            <View style={styles.input}>
              <Entypo
                style={{ marginLeft: 16 }}
                name="mail"
                size={24}
                color="gray"
              />
              <TextInput
                style={{
                  width: 260,
                  marginVertical: 10,
                  marginLeft: 10,
                  color: "black",
                  borderRadius: 80,
                }}
                placeholder="Enter your email.."
              />
            </View>
            <View style={[styles.input, { marginTop: 30 }]}>
              <Feather
                name="lock"
                size={24}
                color="gray"
                style={{ marginLeft: 16 }}
              />
              <TextInput
                style={{
                  width: 260,
                  marginVertical: 10,
                  marginLeft: 10,
                  color: "black",
                }}
                placeholder="Enter your password.."
                secureTextEntry={true}
              />
            </View>
          </View>
          <View
            style={{
              marginTop: 15,
              flexDirection: "row",
              justifyContent: "space-between",
            }}
          >
            <Text style={{ color: "gray", fontWeight: "500" }}>
              Keep me logged in
            </Text>
            <Text style={{ color: "#007FFF", fontWeight: "500" }}>
              Forgot password
            </Text>
          </View>
          <View style={{ marginTop: 50 }}>
            <Pressable
              style={{
                backgroundColor: "#FEBE10",
                width: 200,
                marginLeft: "auto",
                marginRight: "auto",
                padding: 15,
                borderRadius: 5,
              }}
            >
              <Text
                style={{
                  fontWeight: "500",
                  color: "white",
                  textAlign: "center",
                  fontSize: 18,
                }}
              >
                Login
              </Text>
            </Pressable>
          </View>
        </KeyboardAvoidingView>
      </View>
    </SafeAreaView>
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
    paddingVertical: 5,
    backgroundColor: "#D0D0D0",
  },
});

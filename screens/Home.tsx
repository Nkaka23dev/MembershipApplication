import { View, Text, SafeAreaView } from "react-native";
import React from "react";
import Button from "../components/Button";

export default function Home({ navigation }: any) {
  return (
    <SafeAreaView>
      <View>
        <Text style={{ padding: 40 }}>
          {" "}
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Laboriosam
          quisquam velit culpa esse delectus quidem, ad veritatis ipsam sunt
          aliquid quos sequi accusantium reprehenderit asperiores libero alias
          perferendis explicabo! Culpa similique velit, placeat veritatis, quas
          maiores sint debitis incidunt amet ex, repellendus ad nisi. Debitis
          dolorem culpa neque autem, quas perspiciatis saepe, veniam modi
          obcaecati quisquam at nam nemo odit architecto qui rerum? Eveniet
          cumque minus dignissimos nemo repellat provident, a et labore
          excepturi necessitatibus deleniti fuga pariatur quam nihil harum earum
          ipsum. Mollitia ipsum voluptate nisi accusamus dolor repellendus
          exercitationem incidunt illum possimus ipsa similique, quaerat sint
          officia quisquam?
        </Text>
        <Button
          title="Go back"
          navigated={() => navigation.navigate("register")}
        />
      </View>
    </SafeAreaView>
  );
}

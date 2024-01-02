package com.Alquiler.Bicicletas.Gateway.configuration;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.cloud.gateway.route.RouteLocator;
import org.springframework.cloud.gateway.route.builder.RouteLocatorBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class GWConfig {
  @Bean
  public RouteLocator ConfigurationRute(
      RouteLocatorBuilder builder,
      @Value("${gateway.uri-service-estaciones}") String uriServiceEstaciones,
      @Value("${gateway.uri-service-alquileres}") String uriServiceAlquileres) {

    return builder.routes()
        .route(
            p -> p.path("/api/v1/estaciones/**").uri(uriServiceEstaciones))
        .route(
            p -> p.path("/api/v1/tarifas/**").uri(uriServiceAlquileres))
        .build();
  }
}

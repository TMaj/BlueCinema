import React from 'react';
import { Carousel, Image } from 'react-bootstrap'

export default class Welcome extends React.Component {
    render(){
        return( 
          <Carousel>
            <Carousel.Item>
              <Image  src="/img/cinema.jpg" />
              <Carousel.Caption>
                <h3>Blue Cinema - Welcome</h3>
                <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
              </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item>
              <img  src="/img/cinema1.jpg" />
              <Carousel.Caption>
                <h3>Watch greatest hits with us</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
              </Carousel.Caption>
            </Carousel.Item>
            <Carousel.Item>
              <img src="/img/cinema2.jpg" />
              <Carousel.Caption>
                <h3>Best prices for best films</h3>
                <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
              </Carousel.Caption>
            </Carousel.Item>
          </Carousel> 
          );
    }

}